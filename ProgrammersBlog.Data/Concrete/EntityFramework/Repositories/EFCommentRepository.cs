﻿using Microsoft.EntityFrameworkCore;
using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Shared.Data.Concrete.EntityFramework;

namespace ProgrammersBlog.Data.Concrete.EntityFramework.Repositories
{
    public class EFCommentRepository : EfEntityRepositoryBase<Comment>, ICommentRepository
    {
        public EFCommentRepository(DbContext context) : base(context)
        {
        }
    }
}
