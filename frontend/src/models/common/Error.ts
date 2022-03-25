interface Error {
    code: string;
    field?: string;
    message?: string;
    parameters?: Record<string, string>;
  }
  
  export default Error;
  