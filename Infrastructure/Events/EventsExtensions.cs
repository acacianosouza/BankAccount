using Infrastructure.Http.Response;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Events
{
    public static class EventsExtensions
    {
        public static Microsoft.Extensions.Logging.EventId ToEventId(this Event @event)
        {
            return new Microsoft.Extensions.Logging.EventId(@event.Code, @event.Name);
        }

        public static ErrorResponse ToErrorResponse(this Event @event)
        {
            return new ErrorResponse { Code = @event.Code, Message = @event.Message };
        }

        public static IEnumerable<ErrorResponse> ToErrorResponse(this IEnumerable<Event> events)
        {
            return events.Select(@event => @event.ToErrorResponse());
        }

        public static TError ToErrorResponse<TError>(this Event @event) where TError : ErrorResponse
        {
            var error = (TError)Activator.CreateInstance(typeof(TError));
            error.Code = @event.Code;
            error.Message = @event.Message;
            return error;
        }

        public static IEnumerable<TError> ToErrorResponse<TError>(this IEnumerable<Event> events) where TError : ErrorResponse
        {
            return events.Select(@event => @event.ToErrorResponse<TError>());
        }
    }
}
