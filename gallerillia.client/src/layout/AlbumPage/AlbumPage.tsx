import { FC, useEffect, useState } from "react";
import { Pagination } from "../../components/Pagination/Pagination";
import styles from "./AlbumPage.module.scss";
import { Picture } from "../../components/Picture/Picture";
import { useParams } from "react-router-dom";
import { Pictures, fetchPictures } from "../../services/api";
import { toast } from "react-toastify";
import { PicturesNotFound } from "../NotFound/PicturesNotFound";

export const AlbumPage: FC = () => {
    const { id } = useParams();
    const [currentPage, setCurrentPage] = useState<number>(0);
    const [picturesList, setPicturesList] = useState<Pictures>({
        pictures: [],
        totalPages: 1,
    });

    const onChangePage = (page: number) => {
        setCurrentPage(page);
    };
    useEffect(() => {
        if (id) {
            const response = fetchPictures(id, currentPage);
            response
                .then((data) => {
                    setPicturesList(data);
                })
                .catch((error: any) => {
                    if (error.response) {
                        toast.error(error.response.data);
                    }
                });
        } else {
            toast.error("Couldn't load the pictures, try again later!");
        }
    }, [id, currentPage]);

    return (
        <div className={styles["album-page"]}>
            <div className={styles["container"]}>
                {picturesList.pictures.length > 0 ? (
                    <>
                        <div className={styles["pictures__list"]}>
                            {picturesList.pictures.map((picture) => (
                                <Picture key={picture.id} {...picture} />
                            ))}
                        </div>
                        <Pagination
                            currentPage={currentPage}
                            onChangePage={onChangePage}
                            totalPages={picturesList.totalPages}
                        />
                    </>
                ) : (
                    <PicturesNotFound />
                )}
            </div>
        </div>
    );
};
