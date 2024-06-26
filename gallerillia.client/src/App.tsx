import "./App.css";
import { Header } from "./layout/Header/Header";
import { Home } from "./layout/Home/Home";
import { Route, Routes } from "react-router-dom";
import { ToastContainer } from "react-toastify";
import { Suspense, lazy, useState } from "react";
import { Cloudinary } from "@cloudinary/url-gen/instance/Cloudinary";

const Login = lazy(
    () => import(/* webpackChunkName: "Login" */ "./layout/Auth/Login")
);

const Register = lazy(
    () => import(/* webpackChunkName: "Register" */ "./layout/Auth/Register")
);

const AlbumPage = lazy(
    () =>
        import(
            /* webpackChunkName: "AlbumPage" */ "./layout/AlbumPage/AlbumPage"
        )
);

const MyAlbumsPage = lazy(
    () =>
        import(
            /* webpackChunkName: "MyAlbumsPage" */ "./layout/MyAlbumsPage/MyAlbumsPage"
        )
);

const NotFound = lazy(
    () =>
        import(/* webpackChunkName: "NotFound" */ "./layout/NotFound/NotFound")
);

function App() {
    const user = localStorage.getItem("userId");
    const [isLogged, setIsLogged] = useState<boolean>(user?.length! > 0);
    const [currentPage, setCurrentPage] = useState<string>("Home");
    const cld = new Cloudinary({
        cloud: {
            cloudName: "main",
        },
    });

    return (
        <>
            <Header
                isLogged={isLogged}
                setIsLogged={setIsLogged}
                currentPage={currentPage}
                setCurrentPage={setCurrentPage}
            />
            <ToastContainer className="toast" />
            <Routes>
                <Route path="/" element={<Home />} />
                <Route
                    path="/login"
                    element={
                        <Suspense>
                            <Login
                                setIsLogged={setIsLogged}
                                currentPage={currentPage}
                                setCurrentPage={setCurrentPage}
                            />
                        </Suspense>
                    }
                />
                <Route
                    path="/register"
                    element={
                        <Suspense>
                            <Register
                                setIsLogged={setIsLogged}
                                currentPage={currentPage}
                                setCurrentPage={setCurrentPage}
                            />
                        </Suspense>
                    }
                />
                <Route
                    path="/my-albums"
                    element={
                        <Suspense>
                            <MyAlbumsPage
                                isLogged={isLogged}
                                setCurrentPage={setCurrentPage}
                            />
                        </Suspense>
                    }
                />
                <Route
                    path="/pictures/:id"
                    element={
                        <Suspense>
                            <AlbumPage />
                        </Suspense>
                    }
                />
                <Route path="*" element={<NotFound />} />
            </Routes>
        </>
    );
}

export default App;
