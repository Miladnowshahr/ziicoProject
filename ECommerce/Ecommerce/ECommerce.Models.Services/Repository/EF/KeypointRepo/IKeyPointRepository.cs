using ECommerce.Models.Model.KeyPoints;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models.Services.Repository.EF.KeypointRepo
{
    public interface IKeyPointRepository
    {
        Task AddAsync(KeyPoint keyPoint);
        void Update(KeyPoint keyPoint);

        Task<KeyPoint> KeyPointAsync(int id);

        Task<IEnumerable<KeyPoint>> KeyPointsAsync(int?id,int? productId,string title,KeyPointType? type);
        Task RemoveAsync(int id);
        Task SaveAsync();

    }
}