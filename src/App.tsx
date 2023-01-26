import React from 'react';
import { createBrowserRouter, RouterProvider} from "react-router-dom";
import './App.css';
import PokeLayout from './views/PokeLayout';
import ListePkmn from './components/ListePkmn';

import FilteringByType from './components/FilteringByType';
import FilteringByGen from './components/FilteringByGen';

const router = createBrowserRouter([
  {
    path: "/",
    element: <PokeLayout />,
    children: [{
      path: "",
      element: <ListePkmn/>,
    },
    {
      path: "/filteredType",
      element: <FilteringByType />
    },
    {
      path: "/filteredGen",
      element: <FilteringByGen />
    }]
  }
]);

const App: React.FC = () => {
  return (
    <React.StrictMode>
      <RouterProvider router={router} />
    </React.StrictMode>
  );
};

export default App;