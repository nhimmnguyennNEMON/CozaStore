using System;
using BusinessObjects;
using DTO;
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
        //-----------------------------------------------
        public List<CategoryDTO> GetCategories()
        {
            var list = new List<Category>();
            var listDTO = new List<CategoryDTO>();
            try
            {
                using (var context = new CozaStoreDbContext())
                {
                    list = context.Categories.ToList();
                    foreach (var item in list)
                    {
                        listDTO.Add(new CategoryDTO{
                            CategoryId = item.CategoryId,
                            CategoryName = item.CategoryName,
                            Description = item.Description
                        });
                    }
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listDTO;
        }
        //-----------------------------------------------
        public void DeleteCategoryById(int cateID)
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
        public CategoryDTO FindCategoryById(int cid)
        {
            Category cate = new Category();
            CategoryDTO cateDTO = new CategoryDTO();
            try
            {
                using (var context = new CozaStoreDbContext())
                {
                    cate = context.Categories.SingleOrDefault(x => x.CategoryId == cid);
                    cateDTO.CategoryId = cate.CategoryId;
                    cateDTO.CategoryName = cate.CategoryName;
                    cateDTO.Description = cate.Description;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return cateDTO;
        }

        //----------------------------------------------
        public List<CategoryDTO> GetCategoryByName(string cateName)
        {
            List<Category> cateList = new List<Category>();
            List<CategoryDTO> cateListDTO = new List<CategoryDTO>();
            try
            {
                using (var context = new CozaStoreDbContext())
                {
                    cateList = context.Categories.Where(x => x.CategoryName.Contains(cateName)).ToList();
                    foreach (var item in cateList)
                    {
                        cateListDTO.Add(new CategoryDTO{
                            CategoryId = item.CategoryId,
                            CategoryName = item.CategoryName,
                            Description = item.Description
                        });
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return cateListDTO;
        }
        //----------------------------------------------
        public void SaveCategories(CategoryDTO category)
        {
            Category categoryTemp = new Category();
            categoryTemp.CategoryName = category.CategoryName;
            categoryTemp.Description = category.Description;
            try
            {
                using (var context = new CozaStoreDbContext())
                {
                    context.Categories.Add(categoryTemp);
                    context.SaveChanges();
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        //----------------------------------------------
        public void UpdateCategory(CategoryDTO category)
        {
            Category categoryTemp = new Category();
            categoryTemp.CategoryId = category.CategoryId;
            categoryTemp.CategoryName = category.CategoryName;
            categoryTemp.Description = category.Description;
            try
            {
                using (var context = new CozaStoreDbContext())
                {
                    context.Entry<Category>(categoryTemp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.Categories.Update(categoryTemp);
                    context.SaveChanges();
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        //----------------------------------------------
    }
}

