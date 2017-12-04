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
    public class TrainerRatingFactory
    {
        public TrainerRatingGatewayInterface<TrainerRating> GetTrainerRating()
        {
            if (Configure.TRAINERRATINGREAD == 0)
            {
                return TrainerRatingGateway<TrainerRating>.Instance;
            }
            else
            {
                return TrainerRatingXMLGateway<TrainerRating>.Instance;
            }

        }
    }
}
