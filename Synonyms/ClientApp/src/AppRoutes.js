import { AddSynonym } from "./components/AddSynonym";
import { FetchData } from "./components/FetchData";

const AppRoutes = [
    {
    index: true,
    path: '/add',
    element: <AddSynonym />
  },
  {
    path: '/fetch-data',
    element: <FetchData />
  }
];

export default AppRoutes;
