using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using ReportService.Business.Abstract;
using ReportService.Core.Enum;
using ReportService.Core.ResponseTypes;
using ReportService.Entities.Dto.Report;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ReportService.Business.Concrete
{
    public class ReportQueueManager : IReportQueueService
    {
        private readonly IConfiguration _configuration;

        public ReportQueueManager(IConfiguration configuration)
        {
            _configuration = configuration;
        } 

        public async Task<Response<IEnumerable<ReportDto>>> GetList()
        {
            return null;
        }


        public async Task<Response<ReportRequestDto>> CreateReportRequest(ReportRequestDto model)
        {
            try
            {
                IConnection connection = GetConnection();
                IModel channel = GetChannel(connection);
                var exchangeName = _configuration.GetSection("RabbitMQ").GetSection("ExchangeName").Value;

                channel.ExchangeDeclare(exchangeName, ExchangeType.Topic);

                channel.QueueDeclare("CreateReport", false, false, false);
                channel.QueueBind("CreateReport",exchangeName, "CreateReport");

                model.RequestUUID = Guid.NewGuid();

                WriteToQueue(channel, "CreateReport", model);

                var consumerEvent = new EventingBasicConsumer(channel);

                consumerEvent.Received += (ch, ea) =>
                {
                    var modelReceived = JsonConvert.DeserializeObject<Response<string>>(Encoding.UTF8.GetString(ea.Body.ToArray()));
                };

                channel.BasicConsume("CreateReport", true, consumerEvent);


                return Response<ReportRequestDto>.Success(model, Enums.ResponseStatusEnum.Error.GetEnumInteger(), "Report Request in Queue");
            }
            catch (Exception ex)
            {
                return Response<ReportRequestDto>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string>() { ex.Message });
            }
        }



        private void WriteToQueue(IModel channel, string queueName, ReportRequestDto model)
        {
            var messageArr = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(model));
            var exchangeName = _configuration.GetSection("RabbitMQ").GetSection("ExchangeName").Value;
            IBasicProperties props = channel.CreateBasicProperties();
            props.MessageId = model.RequestUUID.ToString();

            channel.BasicPublish(exchangeName, queueName, props, messageArr);
        }


        private IConnection GetConnection()
        {
            var connectionString = _configuration.GetSection("RabbitMQ").GetSection("ConnectionString").Value;

            var connectionFactory = new ConnectionFactory()
            {
                Uri = new Uri(connectionString)
            };

            return connectionFactory.CreateConnection();
        }

        private IModel GetChannel(IConnection connection)
        {
            return connection.CreateModel();
        }
    }
}
