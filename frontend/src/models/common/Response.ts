import Error from "./Error";

enum ResponseState {
  unknown,
  failed,
  succeeded,
}

/** Empty response that can be returned when a call requires a Response, but no API call is required */
export const EmptySuccessResponse: Response<unknown> = {
  state: ResponseState.succeeded,
};

/** Empty response that can be returned when a call requires a Response, but no API call is required */
export const EmptyFailureResponse: Response<unknown> = {
  state: ResponseState.failed,
};

class Response<TModel> {
  payload?: TModel;

  state: ResponseState = ResponseState.unknown;

  errors?: Error[];
}

export { ResponseState };
export default Response;
