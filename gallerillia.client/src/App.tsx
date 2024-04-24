import { Fragment } from "react/jsx-runtime";
import "./App.css";
import { Header } from "./layout/Header/Header";
import { Home } from "./layout/Home/Home";

function App() {

    return (
        <Fragment>
            <Header />
            <Home />
        </Fragment>
    );
}

export default App;
