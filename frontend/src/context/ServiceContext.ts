import React from "react";
import HttpClient from "../services/HttpClient";


export interface ServiceContextContent {
  httpClient: HttpClient
}

const ServiceContext = React.createContext<ServiceContextContent>(
  {} as ServiceContextContent
);

export default ServiceContext;
