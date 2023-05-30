import React from 'react';
import "./styles.css";

const InpurField = () => {
  return (
    <form action="" className='input'>
      <input type='input' placeholder='Enter a task' className='input__box'></input>
      <button className='input__button' type='submit'>Go</button>
    </form>
  )
}

export default InpurField
