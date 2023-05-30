import React from 'react'
import "./styles.css"
import { Todo } from '../Model';
import SingleTodo from './SingleTodo';

interface Props {
    todos: Todo[];
    todos: React.Dispatch<React.SetStateAction<Todo[]>>;
}

const TodoList:React.FC = ({todos, setTodos}): Props => {
  return (
    <div className='todos'>
        {todos.map(todo => (
            <SingleTodo 
                todo={todo}
                key={todo.id}
                todos={todos}
                setTodos={setTodos}

            />
        ))}
      
    </div>
  )
}

export default TodoList;
