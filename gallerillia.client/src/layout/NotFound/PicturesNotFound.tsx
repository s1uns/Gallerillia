import { FC } from "react";
import styles from "./NotFound.module.scss";

export const PicturesNotFound: FC = () => {
    return (
        <div className={styles["not-found"]}>
            <h1>
                <span>࿔ ֶָ֢˚🎞️˖˚ֶָ ‧</span>
            </h1>
            <br />
            <p className={styles["nothing-found"]}> Nothing found</p>
            <p className={styles["description"]}>No pictures here</p>
        </div>
    );
};
