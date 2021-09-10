using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Extensions
{
    public static class RepositoryEmployeeExtensions
    {
        /* public static IQueryable<Employee> FilterEmployees(this IQueryable<Employee>
        employees, uint minAge, uint maxAge) =>
         employees.Where(e => (e.Age >= minAge && e.Age <= maxAge));*/
        public static IQueryable<Image> Search(this IQueryable<Image> image, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return image;
            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return image.Where(e => e.Name.ToLower().Contains(lowerCaseTerm));
        }
    }

}
