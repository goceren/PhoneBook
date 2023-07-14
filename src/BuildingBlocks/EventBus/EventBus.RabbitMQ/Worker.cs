using EventBus.RabbitMQService;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Reflection;

namespace EventBus.RabbitMQ
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _configuration;
        private IConnection _connection;
        private IModel _channel;
        private MethodInfo[] _queueMethods;
        private HandleMethods _handleMethod;

        public Worker(ILogger<Worker> logger, IConfiguration configuration)
        {
            _configuration = configuration;
            _logger = logger;
            _handleMethod = new HandleMethods();
            _queueMethods = typeof(HandleMethods)
                           .GetMethods().Where(i => i.ReturnType == typeof(Task)).ToArray();
            InitRabbitMQ();
        }

        private void InitRabbitMQ()
        {
            var exchangeName = _configuration.GetSection("RabbitMQ").GetValue<string>("ExchangeName");

            _connection = GetConnection();

            _channel = _connection.CreateModel();

            _channel.ExchangeDeclare(exchangeName, ExchangeType.Topic);

            foreach (var item in _queueMethods)
            {
                _channel.QueueDeclare(item.Name, false, false, false, null);
                _channel.QueueBind(item.Name, exchangeName, item.Name + ".*", null);
            }
            _channel.BasicQos(0, 1, false);

            _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (ch, ea) =>
            {
                var content = System.Text.Encoding.UTF8.GetString(ea.Body.ToArray());
                var method = typeof(HandleMethods).GetMethod(ea.RoutingKey);
                var parameterType = method.GetParameters()[0].ParameterType;
                var model = JsonConvert.DeserializeObject(content, parameterType);
                method.Invoke(_handleMethod, new object[1] { model });
                _channel.BasicAck(ea.DeliveryTag, false);
            };

            consumer.Shutdown += OnConsumerShutdown;
            consumer.Registered += OnConsumerRegistered;
            consumer.Unregistered += OnConsumerUnregistered;
            consumer.ConsumerCancelled += OnConsumerConsumerCancelled;
            MethodInfo[] mInfos = typeof(HandleMethods).GetMethods(BindingFlags.Public);

            foreach (var item in _queueMethods)
            {
                _channel.BasicConsume(item.Name, false, consumer);
            }
            return Task.CompletedTask;
        }

        private void OnConsumerConsumerCancelled(object sender, ConsumerEventArgs e) { }
        private void OnConsumerUnregistered(object sender, ConsumerEventArgs e) { }
        private void OnConsumerRegistered(object sender, ConsumerEventArgs e) { }
        private void OnConsumerShutdown(object sender, ShutdownEventArgs e) { }
        private void RabbitMQ_ConnectionShutdown(object sender, ShutdownEventArgs e) { }

        public override void Dispose()
        {
            _channel.Close();
            _connection.Close();
            base.Dispose();
        }

        private IConnection GetConnection()
        {
            var connectionFactory = new ConnectionFactory()
            {
                Uri = new Uri(_configuration.GetSection("RabbitMQ").GetValue<string>("ConnectionString")),
            };

            return connectionFactory.CreateConnection();
        }

    }
}