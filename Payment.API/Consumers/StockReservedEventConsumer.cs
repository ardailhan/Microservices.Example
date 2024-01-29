using MassTransit;
using Shared.Events;

namespace Payment.API.Consumers
{
    public class StockReservedEventConsumer : IConsumer<StockReservedEvent>
    {
        readonly IPublishEndpoint _publishEndpoint;

        public StockReservedEventConsumer(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public Task Consume(ConsumeContext<StockReservedEvent> context)
        {
            //Ödeme işlemleri....

            if (true)
            {
                PaymentCompletedEvent paymentCompletedEvent = new()
                {
                    OrderId = context.Message.OrderId
                };
                _publishEndpoint.Publish(paymentCompletedEvent);
                Console.WriteLine("Ödeme Başarılı");
            }
            else
            {
                //Ödemede bir problem varsa..
                PaymentFailedEvent paymentFailedEvent = new()
                {
                    OrderId = context.Message.OrderId,
                    Message = "Yetersiz Bakiye.."
                };
                _publishEndpoint.Publish(paymentFailedEvent);
                Console.WriteLine("Ödeme Başarılı Değil");
            }
            return Task.CompletedTask;
        }
    }
}
