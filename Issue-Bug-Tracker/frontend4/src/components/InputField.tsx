/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
import React, { useRef } from 'react';
import "./styles.css";


interface Props {
  todo: string;
  setTodo: any;
  handleAdd: (e: React.FormEvent) => void;
}


const InpurField = ({ todo, setTodo, handleAdd }: Props) => {

  const inputRef = useRef < HTMLInputElement > (null);

  return (
    <form action="" className='input' onSubmit={(e) => {
      handleAdd(e);
      inputRef.current?.blur();
    }}>
      <input
        ref={inputRef}
        type='input'
        placeholder='Enter a task'
        className='input__box'
        value={todo}
        onChange={
          (e) => setTodo(e.target.value)
        }>

      </input>
      <button className='input_submit' type='submit'>Go</button>
    </form>
  )
}

export default InpurField;
