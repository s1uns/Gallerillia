import { FC, useEffect, useState } from "react";
import { Pagination } from "../../components/Pagination/Pagination";
import styles from "./AlbumPage.module.scss";
import { Picture } from "../../components/Picture/Picture";
import { useParams } from "react-router-dom";
import { fetchPictures } from "../../services/api";
import { toast } from "react-toastify";
import { PicturesNotFound } from "../NotFound/PicturesNotFound";
import { Pictures } from "../../types/types";

const AlbumPage: FC = () => {
    const { id } = useParams();
    const [currentPage, setCurrentPage] = useState<number>(0);
    const [picturesList, setPicturesList] = useState<Pictures>({
        pictures: [],
        totalPages: 1,
    });
    const [shouldReload, setShouldReload] = useState(true);

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
                        toast.error(error.response.data.message);
                    }
                });
            setShouldReload(false);
        } else {
            toast.error("Couldn't load the pictures, try again later!");
        }
    }, [id, currentPage, shouldReload]);

    return (
        <div className={styles["album-page"]}>
            <div className={styles["container"]}>
                {picturesList.pictures.length > 0 ? (
                    <>
                        <div className={styles["pictures__list"]}>
                            {picturesList.pictures.map((picture) => (
                                <Picture
                                    key={picture.id}
                                    id={picture.id}
                                    authorId={picture.authorId}
                                    imgUrl={picture.imgUrl}
                                    upVotesCount={picture.upVotesCount}
                                    downVotesCount={picture.downVotesCount}
                                    usersVote={picture.usersVote}
                                    onChange={setShouldReload}
                                />
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

export default AlbumPage;
