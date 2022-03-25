import { useContext } from "react";
import ServiceContext, { ServiceContextContent } from "../context/ServiceContext";


const useServices = (): ServiceContextContent => {
  return useContext(ServiceContext);
};

export default useServices;
