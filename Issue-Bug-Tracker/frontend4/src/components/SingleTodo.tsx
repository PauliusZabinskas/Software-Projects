/* eslint-disable @typescript-eslint/no-unused-vars */
import React from 'react'

type Props = {
    todo: Todo,
    todos: Todo[],
    setTodos: React.Dispatch<React.SetStateAction<Todo[]>>
}

const SingleTodo = ({ todo, todos, setTodos}: Props) => {
  return (
    <div>
      
    </div>
  )
}

export default SingleTodo
