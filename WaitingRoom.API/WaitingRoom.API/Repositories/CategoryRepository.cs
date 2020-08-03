using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WaitingRoom.API.Repositories
{
    public class CategoryRepository
    {
        public List<Category> GetAll()
        {
            using( var contxt = new WaitingRoomDbEntities())
            {
                return contxt.Categories.ToList();
            }
        }
        public Category Get(int id)
        {
            using (var contxt = new WaitingRoomDbEntities())
            {
                var category = contxt.Categories.Where(x => x.Id == id).FirstOrDefault();
                if (category == null)
                    throw new Exception($"Category with ID {id} was not found");
                return category;
            }
        }
        public bool Creat(Category category)
        {
            using (var contxt = new WaitingRoomDbEntities())
            {
                try
                {
                    var newCategory = contxt.Categories.Add(category);
                    contxt.SaveChanges();
                    return true;
                }catch
                {
                    return false;
                }
            }
        }
        public bool Update(int id, Category category)
        {
            using (var contxt = new WaitingRoomDbEntities())
            {
                try
                {
                    var categoryToEdit = Get(id);
                    categoryToEdit.Initial = category.Initial;
                    categoryToEdit.Name = category.Name;
                    contxt.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public bool Remove(int id)
        {
            using (var contxt = new WaitingRoomDbEntities())
            {
                try
                {
                    var categoryToRemove = Get(id);
                    contxt.Categories.Remove(categoryToRemove);
                    contxt.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}