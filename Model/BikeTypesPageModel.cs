using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BikeProjectFinal.Data;

namespace BikeProjectFinal.Model
{
    public class BikeTypesPageModel : PageModel
    {
        public List<AssignedTypeData> AssignedTypeDataList;

        public void PopulateAssignedTypeData(BikeProjectFinalContext context, Bike bike)
        {
            var allTypes = context.Type;
            var bikeTypes = new HashSet<int>(bike.BikeTypes.Select(c => c.BikeID));
            AssignedTypeDataList = new List<AssignedTypeData>();
            foreach (var cat in allTypes)
            {
                AssignedTypeDataList.Add(new AssignedTypeData
                {
                    TypeID = cat.ID,
                    Name = cat.TypeName,
                    Assigned = bikeTypes.Contains(cat.ID)
                });
            }
        }

        public void UpdateBikeType(BikeProjectFinalContext context,
            string[] selectedTypes, Bike BikeToUpdate)
        {
            if (selectedTypes == null)
            {
                BikeToUpdate.BikeTypes = new List<BikeType>();
                return;
            }
            var selectedTypesHS = new HashSet<string>(selectedTypes);
            var bikeTypes = new HashSet<int>
                (BikeToUpdate.BikeTypes.Select(c => c.Type.ID));
            foreach (var cat in context.Type)
            {
                if (selectedTypesHS.Contains(cat.ID.ToString()))
                {
                    if(!bikeTypes.Contains(cat.ID))
                    {
                        BikeToUpdate.BikeTypes.Add(
                            new BikeType
                            {
                                BikeID = BikeToUpdate.ID,
                                TypeID = cat.ID
                            });
                    }
                }
                else
                {
                    if(bikeTypes.Contains(cat.ID))
                    {
                        BikeType courseToRemove = BikeToUpdate.BikeTypes.SingleOrDefault(i => i.TypeID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
