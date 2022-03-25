import { ReactElement } from "react";
import apiUrls from "../../constants/apiUrls";
import ServiceContext from "../../context/ServiceContext";
import { backendUrl } from "../../environment/backendUrl.local";
import useServices from "../../hooks/useServices";
import { FoodItem } from "../../models/FoodItem";
import HttpClient from "../../services/HttpClient";




const FoodList = (): ReactElement => {
    
    const {
        httpClient
      } = useServices();

      //ToDo
//use a layer of abstraction for food, pass api url

const foodItems await httpClient.get(`${backendUrl}/${apiUrls.foodItems.entity}`);


      return (
       <h2>Food List</h2>
<li>
{foodItems.map}
</li>
    );
  
    
  };

  export default FoodList;