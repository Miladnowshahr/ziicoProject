using ECommerce.Models.Models.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models.Services.Repository.EF.TagRepo
{
    public interface ITagValueRepository
    {
        Task AddAsync(TagValue tagvalue);
        Task SaveAsync();
        Task<TagValue> GetTagValueAsync(int id);

        Task<IEnumerable<TagValue>> GetTagValuesAsync(int? id, string title);

        void Update(TagValue tagvalue);

        Task Remove(int id);
    }
}
