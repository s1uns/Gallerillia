import { FC, useEffect, useState } from "react";
import styles from "./Home.module.scss";
import { Pagination } from "../../components/Pagination/Pagination";
import { AlbumsList } from "../../components/AlbumsList/AlbumsList";
import { toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import { Albums, fetchAlbums } from "../../services/api";
import { AlbumsNotFound } from "../NotFound/AlbumsNotFound";

export const Home: FC = () => {
    const [currentPage, setCurrentPage] = useState<number>(0);
    const [albumsList, setAlbumsList] = useState<Albums>({
        albums: [],
        totalPages: 1,
    });
    const onChangePage = (page: number) => {
        setCurrentPage(page);
    };
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
                {albumsList.albums.length > 0 ? (
                    <>
                        <AlbumsList
                            albumsType="All Albums"
                            albums={albumsList.albums}
                        />
                        <Pagination
                            currentPage={currentPage}
                            onChangePage={onChangePage}
                            totalPages={albumsList.totalPages}
                        />
                    </>
                ) : (
                    <AlbumsNotFound />
                )}
            </div>
        </div>
    );
};
