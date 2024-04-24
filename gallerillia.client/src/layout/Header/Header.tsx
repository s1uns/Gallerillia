import { FC } from "react";
import logo from "../../../public/logo-transparent-svg.svg"
import styles from "./Header.module.scss";
import { Button } from "../../components/Button/Button";

export const Header: FC = () => {
    return (
        <div className={styles.header}>
            <div className={styles.container}>
                <div className={styles.logo__container}>
                    <img src={logo} alt="logo" />
                </div>
                <nav className={styles.nav}>
                    <p>Home</p>
                    <p>My albums</p>
                    <p>My profile</p>
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
