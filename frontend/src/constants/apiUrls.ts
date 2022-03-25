const foodItemsBasePath = "FoodItems";



const apiUrls = {
    foodItems: {
      getOne: (id: string): string => `${foodItemsBasePath}/${id}`,
      entity: foodItemsBasePath
      }
}
    
    
export default apiUrls;
      