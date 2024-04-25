import { FC, useEffect, useState } from "react";
import { AlbumProps } from "../../components/Album/Album";
import styles from "./Home.module.scss";
import { Pagination } from "../../components/Pagination/Pagination";
import { AlbumsList } from "../../components/AlbumsList/AlbumsList";
import axios from "axios";
import { toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

type Albums = {
    albums: AlbumProps[];
    totalPages: number;
};

export const fetchAlbums = async (currentPage: number) => {
    const { data } = await axios.get<Albums>(
        `${import.meta.env.VITE_ASPNETCORE_HTTPS_PORT}Album?page=${currentPage}`
    );

    return data;
};

export const Home: FC = () => {
    const [currentPage, setCurrentPage] = useState<number>(1);
    const [albumsList, setAlbumsList] = useState<Albums>({
        albums: [],
        totalPages: 1,
    });
    useEffect(() => {
        const response = fetchAlbums(currentPage);
        response
            .then((data) => {
                setAlbumsList(data);
            })
            .catch((error: any) => {
                if (error.response) {
                    toast.error(error.response.data);
                } else {
                    toast.error("Couldn't load the albums, try again later!");
                }
            });
    }, [currentPage]);
    return (
        <div className={styles["home"]}>
            <div className={styles["container"]}>
                <AlbumsList
                    albumsType="All Albums"
                    albums={albumsList.albums}
                />
                <Pagination
                    currentPage={currentPage}
                    onChangePage={() => {}}
                    totalPages={albumsList.totalPages}
                />
            </div>
        </div>
    );
};
