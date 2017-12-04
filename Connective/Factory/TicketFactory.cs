using Connective.Abstract;
using Connective.Backup;
using Connective.TableGateway;
using Connective.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connective.Factory
{
    public class TicketFactory
    {
        public TicketGatewayInterface<Ticket> GetTicket()
        {
            if (Configure.TICKETREAD == 0)
            {
                return TicketGateway<Ticket>.Instance;
            }
            else
            {
                return TicketXMLGateway<Ticket>.Instance;
            }

        }
    }
}
