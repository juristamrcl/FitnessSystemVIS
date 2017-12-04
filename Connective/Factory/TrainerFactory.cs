using Connective.Abstract.Interface;
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
    public class TrainerFactory
    {
        public TrainerGatewayInterface<Trainer> GetTrainer()
        {
            if (Configure.TRAINERREAD == 0)
            {
                return TrainerGateway<Trainer>.Instance;
            }
            else
            {
                return TrainerXMLGateway<Trainer>.Instance;
            }

        }
    }
}
