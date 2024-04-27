import { FC, useEffect, useState } from "react";
import { Album, AlbumProps } from "../Album/Album";
import styles from "./AlbumList.module.scss";
import { toast } from "react-toastify";
import { AlbumsList, fetchAlbums, fetchOwnAlbums } from "../../services/api";
import { Pagination } from "../Pagination/Pagination";
import { AlbumsNotFound } from "../../layout/NotFound/AlbumsNotFound";

interface AlbumListProps {
    albumsType: "all-albums" | "my-albums";
}

export const AlbumList: FC<AlbumListProps> = (props: AlbumListProps) => {
    const userId = localStorage.getItem("userId");
    const userRole = localStorage.getItem("userRole");
    const [reload, setReload] = useState(true);
    const [currentPage, setCurrentPage] = useState<number>(0);
    const onChangePage = (page: number) => {
        setCurrentPage(page);
    };
    const [albumsList, setAlbumsList] = useState<AlbumsList>({
        albums: [],
        totalPages: 1,
    });

    useEffect(() => {
        if (props.albumsType == "my-albums") {
            const response = fetchOwnAlbums(currentPage);
            response
                .then((data) => {
                    setAlbumsList(data);
                })
                .catch((error: any) => {
                    if (error.response) {
                        toast.error(error.response.data.message);
                    } else {
                        toast.error(
                            "Couldn't load your albums, try again later!"
                        );
                    }
                });
        }

        if (props.albumsType == "all-albums") {
            const response = fetchAlbums(currentPage);
            response
                .then((data) => {
                    setAlbumsList(data);
                })
                .catch((error: any) => {
                    if (error.response) {
                        toast.error(error.response.data.message);
                    } else {
                        toast.error(
                            "Couldn't load the albums, try again later!"
                        );
                    }
                });
        }

        setReload(false)
    }, [currentPage, reload]);

    return (
        <div className={styles["container"]}>
            <div className={styles["albums"]}>
                <div className={styles["albums__list"]}>
                    {albumsList.albums.length > 0 ? (
                        <>
                            {albumsList.albums.map((album) => (
                                <Album
                                    key={album.id}
                                    id={album.id}
                                    title={album.title}
                                    imgUrl={album.imgUrl}
                                    author={album.author}
                                    authorId={album.authorId}
                                    canBeDeleted={
                                        userId == album.authorId ||
                                        userRole == "Administrator"
                                    }
                                    onDelete={setReload}
                                />
                            ))}
                        </>
                    ) : (
                        <AlbumsNotFound />
                    )}
                </div>
            </div>
            <Pagination
                currentPage={currentPage}
                onChangePage={onChangePage}
                totalPages={albumsList.totalPages}
            />
        </div>
    );
};
