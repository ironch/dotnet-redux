using System;

namespace dotnet.redux.Interfaces
{
    public interface IReduxBuilder<TState, TActionType>
        where TState : IState
        where TActionType : Enum
    {
        IReduxBuilderErrorHandler<TState, TActionType> WithInitialState(TState initialState);
    }
    
    public interface IReduxBuilderErrorHandler<TState, TActionType>
        where TState : IState
        where TActionType : Enum
    {
        IReduxBuilderWithMiddleware<TState, TActionType> WithErrorHandler(Action<TState, IAction<TActionType>> errorHandler);
    }

    public interface IReduxBuilderWithMiddleware<TState, TActionType>
        where TState : IState
        where TActionType : Enum
    {
        IReduxBuilderReducers<TState, TActionType> WithMiddleware(Func<TState, TState> middleware);
    }
    
    public interface IReduxBuilderReducers<TState, TActionType>
        where TState : IState
        where TActionType : Enum
    {
        IReduxBuilderReducers<TState, TActionType> WithReducer<TAction>(Func<TActionType, bool> predicate,
            Func<TState, TAction, TState> handler) where TAction : IAction<TActionType>;

        IRedux<TState, TActionType> Build();
    }
}