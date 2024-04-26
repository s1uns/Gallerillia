import { FC, useEffect, useState } from "react";
import { AlbumList } from "../../components/AlbumList/AlbumList";
import { Pagination } from "../../components/Pagination/Pagination";
import styles from "./MyAlbumsPage.module.scss";
import { AlbumsList, fetchOwnAlbums } from "../../services/api";
import { toast } from "react-toastify";

const MyAlbumsPage: FC = () => {
    const [isLoading, setisLoading] = useState(true);

    const [currentPage, setCurrentPage] = useState<number>(0);
    const onChangePage = (page: number) => {
        setCurrentPage(page);
    };
    const [albumsList, setAlbumsList] = useState<AlbumsList>({
        albums: [],
        totalPages: 1,
    });

    useEffect(() => {
        const response = fetchOwnAlbums(currentPage);
        response
            .then((data) => {
                setisLoading(false);
                setAlbumsList(data);
            })
            .catch((error: any) => {
                setisLoading(false);
                if (error.response) {
                    toast.error(error.response.data.message);
                } else {
                    toast.error("Couldn't load your albums, try again later!");
                }
            });
    }, [currentPage, isLoading]);
    return (
        <div className={styles["album-page"]}>
            <div className={styles["container"]}>
                <AlbumList albums={albumsList.albums} />
                <Pagination
                    currentPage={currentPage}
                    onChangePage={onChangePage}
                    totalPages={albumsList.totalPages}
                />
            </div>
        </div>
    );
};

export default MyAlbumsPage;
