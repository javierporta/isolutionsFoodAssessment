import React, { PropsWithChildren, ReactElement } from "react";
import HttpClient from "../../services/HttpClient";
import ServiceContext, { ServiceContextContent } from "../ServiceContext";

const ServiceContextProvider = ({
  children,
}: PropsWithChildren<unknown>): ReactElement => {
  const httpClient = new HttpClient();

  const services: ServiceContextContent = {
    httpClient: httpClient,
  };

  return (
    <ServiceContext.Provider value={services}>
      {children}
    </ServiceContext.Provider>
  );
};

export default ServiceContextProvider;
