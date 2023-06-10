// import Heading from "./components/Heading"
import { useState } from "react";
import "./App.css";
import TodoList from "./components/TodoList";
import InputField from "./components/InputField";
import { Todo } from "./model";
import SearchField from "./components/nav/SearchField";


const App: React.FC = () => {


  // eslint-disable-next-line @typescript-eslint/no-unused-vars
  const [todo, setTodo] = useState < string > ("");
  const [todos, setTodos] = useState < Todo[] > ([]);
  const [searchQuery, setSearchQuery] = useState<string>("");


  const handleAdd = (e: React.FormEvent) => {
    e.preventDefault();

    if (todo) {
      setTodos([...todos, { id: Date.now(), todo: todo, isDone: false }]);
      setTodo("");
    }

  };

  console.log(todos);

  return (
    <div className="App">
      
        <ul >
          <li className="heading f1 tc">Taskify</li>
          <li className="search__box" style={{justifyContent: 'flex-end'}} ><SearchField searchQuery={searchQuery} setSearchQuery={setSearchQuery} /></li>
        </ul>

      <InputField todo={todo} setTodo={setTodo} handleAdd={handleAdd} />
      <section className="cf">
        <div className="fl w-100 w-50-m w-25-l bg-black-10 tc pv4">
        <TodoList todos={todos.filter(todo => todo.todo.includes(searchQuery))} setTodos={setTodos} />
        </div>
        <div className="fl w-100 w-50-m w-25-l bg-black-05 tc pv4">In progress</div>
        <div className="fl w-100 w-50-m w-25-l bg-black-20 tc pv4">Completed</div>
        
      </section>
      

    </div>
  )
}

export default App
