import "./App.css";
import { Header } from "./layout/Header/Header";
import { Home } from "./layout/Home/Home";
import { Route, Routes } from "react-router-dom";
import { NotFound } from "./layout/NotFound/NotFound";
import { MyAlbumsPage } from "./layout/MyAlbumsPage/MyAlbumsPage";
import { AlbumPage } from "./layout/AlbumPage/AlbumPage";

function App() {
    return (
        <>
            <Header />
            <Routes>
                <Route path="/" element={<Home />} />
                <Route path="/my-albums" element={<MyAlbumsPage />} />
                <Route path="/pictures" element={<AlbumPage />} />
                <Route path="*" element={<NotFound />} />
            </Routes>
        </>
    );
}

export default App;
