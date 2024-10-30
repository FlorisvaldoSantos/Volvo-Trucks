import { BrowserRouter, Route, Routes } from "react-router-dom";
import "./App.css";

import Home from "./pages/Home"
import About from "./pages/About"
import MenuNavbar from "./components/MenuNavBar";
import Truck from "./pages/Truck";
 
function App() {
  return (
    <div>
       
       <div className="App">
          <BrowserRouter>
              <MenuNavbar />
              <Routes>
                <Route path="/" element={<Home/> }/>
                <Route path="/about" element={<About/>}/>
                <Route path="/trucks" element={<Truck/>} />
                <Route path="/trucks/:id" element={<Truck/>} />
              </Routes>
            </BrowserRouter>
       </div>
    </div>
  );
}

export default App;
