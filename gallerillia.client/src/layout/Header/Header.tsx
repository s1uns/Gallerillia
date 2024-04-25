import { FC, useState } from "react";
import logo from "../../../public/logo-transparent-svg.svg";
import styles from "./Header.module.scss";
import { Button } from "../../components/Button/Button";
import { Link } from "react-router-dom";

export const Header: FC = () => {
    const [currentPage, setCurrentPage] = useState<string>("Home");

    const ChangePage = (page: string) => {
        setCurrentPage((p) => page);
    };
    return (
        <div className={styles.header}>
            <div className={styles.container}>
                <div className={styles.logo__container}>
                    <img src={logo} alt="logo" />
                </div>
                <div className={styles["current-page"]}>
                    <h1>{currentPage}</h1>
                </div>
                <nav className={styles.nav}>
                    <Link
                        className={styles["nav-link"]}
                        to="/"
                        onClick={() => ChangePage("Home")}
                    >
                        Home
                    </Link>
                    <Link
                        className={styles["nav-link"]}
                        to="/my-albums"
                        onClick={() => ChangePage("My Albums")}
                    >
                        My Albums
                    </Link>
                </nav>
                <div className={styles.auth}>
                    <Button title={"Login"}>
                        <h1>Login</h1>
                    </Button>
                    <Button customStyles={styles["sign-up"]} title={"Sign Up"}>
                        <h1>Sign Up</h1>
                    </Button>
                </div>
            </div>
        </div>
    );
};
