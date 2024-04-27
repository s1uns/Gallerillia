import { FC } from "react";
import styles from "./NotFound.module.scss";

const NotFound: FC = () => {
    return (
        <div className={styles["not-found"]}>
            <h1>
                <span>🕵🏿</span>
            </h1>
            <p className={styles["nothing-found"]}> Nothing found</p>
            <p className={styles["description"]}>No such page on the website</p>
        </div>
    );
};

export default NotFound;
