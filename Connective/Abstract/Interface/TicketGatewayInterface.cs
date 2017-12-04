using Connective.Tables;

namespace Connective.Abstract
{
    public interface TicketGatewayInterface<T> : Gateway<T>
        where T : Ticket
    {
    }
}
