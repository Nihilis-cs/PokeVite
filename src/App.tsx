import React from 'react';
import { createBrowserRouter, RouterProvider } from "react-router-dom";
import './App.css';
import PokeLayout from './views/PokeLayout';
import ListePkmn from './components/ListePkmn';

import FilteringByType from './components/FilteringByType';
import FilteringByGen from './components/FilteringByGen';
import FilteringByUser from './components/FilteringByUser';
import Tests from './components/Tests';
import DetailsList from './components/DetailsList';

const router = createBrowserRouter([
  {
    path: "/",
    element: <PokeLayout />,
    children: [{
      path: "",
      element: <ListePkmn />,
    },
    {
      path: "/filteredType",
      element: <FilteringByType />
    },
    {
      path: "/filteredGen",
      element: <FilteringByGen />
    },
    {
      path: "/filteredUser",
      element: <FilteringByUser />
    },
    {
      path:"/tests",
      element: <Tests />
    },
    {
      path:"/collection/:colid",
      element: <DetailsList />
    }
  ]

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