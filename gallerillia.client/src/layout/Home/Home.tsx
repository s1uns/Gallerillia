import { FC } from "react";
import styles from "./Home.module.scss";
import { AlbumList } from "../../components/AlbumList/AlbumList";
import "react-toastify/dist/ReactToastify.css";

export const Home: FC = () => {
    return (
        <div className={styles["album-page"]}>
            <AlbumList albumsType="all-albums" shouldRefill={false} />
        </div>
    );
};
