using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Shared.Utilities.Results.Abstract
{
    public interface IDataResult<out T>:IResult // neden out örnek ben bir categoriyi tek de list olarak da taşımak isterim
    {
        public T Data { get; } // new DataResult<Category>(ResultStatus.Success,category)
                               // new DataResult<IList<Category>>(ResultStatus.Success,categoryList)

    }
}
