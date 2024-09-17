import { Ganhadores } from "./components/Ganhadores";
import { Home } from "./components/Home";

const AppRoutes = [
  {
    index: true,
    element: <Home />,
  },
  {
    path: "/ganhadores",
    element: <Ganhadores />,
  }
];

export default AppRoutes;
