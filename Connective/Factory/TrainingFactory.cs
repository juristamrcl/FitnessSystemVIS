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
    public class TrainingFactory
    {
        public TrainingGatewayInterface<Training> GetTraining()
        {
            if (Configure.TRAININGREAD == 0)
            {
                return TrainingGateway<Training>.Instance;
            }
            else
            {
                return TrainingXMLGateway<Training>.Instance;
            }

        }
    }
}
