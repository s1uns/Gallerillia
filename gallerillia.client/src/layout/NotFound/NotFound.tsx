import { FC } from "react";
import styles from "./NotFound.module.scss";

export const NotFound: FC = () => {
    return (
        <div className={styles["not-found"]}>
            <h1>
                <span>🤷‍♂️</span>
                <br />
                <br />
                Nothing found
            </h1>
            <p className={styles["description"]}>No such page on the website</p>
        </div>
    );
};
