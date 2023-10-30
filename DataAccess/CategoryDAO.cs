using System;
using BusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class CategoryDAO
    {
        private static CategoryDAO instance = null;
        private static readonly object instanceLock = new object();
        private CategoryDAO() { }

        public static CategoryDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CategoryDAO();
                    }
                    return instance;
                }
            }
        }

        public List<Category> GetCategories()
        {
            var list = new List<Category>();
            try
            {
                using (var context = new CozaStoreDbContext())
                {
                    list = context.Categories.ToList();
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return list;
        }

        //-----------------------------------------------

        //-----------------------------------------------
        public void DeleteCategory(int cateID)
        {
            try
            {
                using (var context = new CozaStoreDbContext())
                {
                    var category = context.Categories.SingleOrDefault(c => c.CategoryId == cateID);
                    context.Categories.Remove(category);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //----------------------------------------------
        public Category FindCategoryById(int cid)
        {
            Category cate = new Category();
            try
            {
                using (var context = new CozaStoreDbContext())
                {
                    cate = context.Categories.SingleOrDefault(x => x.CategoryId == cid);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return cate;
        }

        //----------------------------------------------
        public List<Category> GetCategoryByName(string cateName)
        {
            List<Category> cateList = new List<Category>();
            try
            {
                using (var context = new CozaStoreDbContext())
                {
                    cateList = context.Categories.Where(x => x.CategoryName.Contains(cateName)).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return cateList;
        }
    }
}

