import { FC, useEffect, useState } from "react";
import { AlbumList } from "../../components/AlbumList/AlbumList";
import { Pagination } from "../../components/Pagination/Pagination";
import styles from "./MyAlbumsPage.module.scss";
import { AlbumsList, fetchOwnAlbums } from "../../services/api";
import { toast } from "react-toastify";

const MyAlbumsPage: FC = () => {
    return (
        <div className={styles["album-page"]}>
            <AlbumList albumsType="my-albums" />
        </div>
    );
};

export default MyAlbumsPage;
