import axios, {
    AxiosError,
    AxiosInstance,
    AxiosRequestConfig,
    AxiosResponse,
  } from "axios";
  
  import ResponseModel, { ResponseState } from "../models/common/Response";   
  
  type ResponseType = "blob" | "document" | "arraybuffer" | "json" | "text";
  
  interface DoRequestArgs<TData> {
    method: "GET" | "POST" | "DELETE" | "PUT";
    url: string;
    data?: TData | FormData;
    language?: string;
    responseType?: ResponseType;
  }
  class HttpClient {
    private baseUrl =
      process.env.NODE_ENV === "development"
        ? `${process.env.REACT_APP_LOCAL_API_URL}/api`
        : "/api";
  
    private readonly axiosInstance: AxiosInstance;
  
    constructor() {
      this.axiosInstance = axios.create();
     
    }
  
    public async get<TResponse, TParams = undefined>(
      url: string,
      params?: TParams,
    ): Promise<ResponseModel<TResponse>> {
      if (params) {
        return this.doRequest<TResponse, TParams>({
          method: "GET",
          url: url,
          data: params,
        });
      }
      return this.doRequest<TResponse>({ method: "GET", url: url });
    }
  
    public async download<T>(url: string): Promise<ResponseModel<T>> {
      return this.doRequest<T>({ method: "GET", url: url, responseType: "blob" });
    }
  
    public async export<T, TParams = Record<string, never>>(
      url: string,
      language: string,
      parameters?: TParams
    ): Promise<ResponseModel<T>> {
      return this.doRequest<T, TParams>({
        method: "GET",
        url: url,
        language: language,
        responseType: "blob",
        data: parameters,
      });
    }
  
    public async put<T, TResponse = T>(
      url: string,
      data: T | FormData
    ): Promise<ResponseModel<TResponse>> {
      return this.doRequest<TResponse, T>({
        method: "PUT",
        url: url,
        data: data,
      });
    }
  
  
    public async post<T, TResponse = T>(
      url: string,
      data: T | FormData
    ): Promise<ResponseModel<TResponse>> {
      return this.doRequest<TResponse, T>({
        method: "POST",
        url: url,
        data: data,
      });
    }
  
    public async delete<T>(url: string): Promise<ResponseModel<T>> {
      return this.doRequest<T>({ method: "DELETE", url: url });
    }
  
    private async doRequest<TResponse, TData = undefined>({
      method,
      url,
      data,
      language,
      responseType,
          }: DoRequestArgs<TData>): Promise<ResponseModel<TResponse>> {
      try {
        const config: AxiosRequestConfig = {};

  
        if (language) {
          config.headers = { ...config.headers, "accept-Language": language };
        }
  
        if (responseType) {
          config.responseType = responseType;
        }
  
        const callUrl = `${this.baseUrl}/${url}`;
        let response: AxiosResponse<TResponse> | undefined;
        switch (method) {
          case "GET": {
            response = await this.axiosInstance.get(callUrl, {
              ...config,
              params: data,
            });
            break;
          }
          case "POST": {
            response = await this.axiosInstance.post(callUrl, data, config);
            break;
          }
          case "PUT": {
            response = await this.axiosInstance.put(callUrl, data, config);
            break;
          }
          case "DELETE": {
            response = await this.axiosInstance.delete(callUrl, {
              ...config,
              params: data,
            });
            break;
          }
          default:
            break;
        }
        const responseModel: ResponseModel<TResponse> = {
          payload: response?.data,
          state: ResponseState.succeeded,
        };
        return responseModel;
      } catch (error) {
        const response = await this.buildErrorResponseModel<TResponse>(
          error as AxiosError | string,
          responseType
        );
        return response;
      }
    }
  
    private buildErrorResponseModel = async <T>(
      error: AxiosError | string,
      responseType?: ResponseType
    ) => {
      const responseModel: ResponseModel<T> = {
        state: ResponseState.failed,
      };
      if (this.isAxiosError(error) && error.response?.data) {
        if (responseType === "blob") {
          const errorString = await error.response.data.text();
          responseModel.errors = JSON.parse(errorString).errors;
        } else {
          responseModel.errors = error.response.data.errors;
        }
      } else {
        responseModel.errors = [{ code: "errors:ERR_APINotReachable" }];
      }
      return responseModel;
    };
  
    private isAxiosError = (error: AxiosError | unknown): error is AxiosError => {
      return (error as AxiosError).response !== undefined;
    };
  

  }
  
  export default HttpClient;
  