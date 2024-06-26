﻿using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Data.Concrete.EntityFramework.Contexts;
using ProgrammersBlog.Data.Concrete.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private EFArticleRepository _articleRepository;
        private EFCategoryRepository _categoryRepository;
        private EFCommentRepository _commentRepository;
       
        public UnitOfWork(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        // ?? = = Operatörü ile bir değişkenin null olduğu durumlarda alternatif döneceğim
        public IArticleRepository Articles => _articleRepository ?? new EFArticleRepository(_context);   // biri benden IArticleRepository isterse ben somtunu dönüyorum

        public ICategoryRepository Categories => _categoryRepository ?? new EFCategoryRepository(_context);

        public ICommentRepository Comments => _commentRepository ?? new EFCommentRepository(_context);

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
