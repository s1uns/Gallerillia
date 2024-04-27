import { ChangeEvent, FC, useEffect, useState } from "react";
import { Pagination } from "../../components/Pagination/Pagination";
import styles from "./AlbumPage.module.scss";
import { Picture } from "../../components/Picture/Picture";
import { useParams } from "react-router-dom";
import { fetchPictures } from "../../services/api";
import { toast } from "react-toastify";
import { PicturesNotFound } from "../NotFound/PicturesNotFound";
import { Pictures } from "../../types/types";
import { DrugNDropWindow } from "../../components/DialogWindow/DrugNDropWindow";
import { Button } from "../../components/Button/Button";

const AlbumPage: FC = () => {
    const { id } = useParams();
    const [currentPage, setCurrentPage] = useState<number>(0);
    const [picturesList, setPicturesList] = useState<Pictures>({
        pictures: [],
        totalPages: 1,
    });
    const [picture, setPicture] = useState<any[]>([]);
    const [shouldReload, setShouldReload] = useState(false);
    const userId = localStorage.getItem("userId");
    const userRole = localStorage.getItem("userRole");
    const onChangePage = (page: number) => {
        setCurrentPage(page);
    };

    const onPictureCreate = () => {};

    const handleChange = (event: ChangeEvent<HTMLInputElement>) => {
        const preset_key = import.meta.env.VITE_PRESET_KEY;

        const file = event.target.files![0];
        const formData = new FormData();
        formData.append("file", file);
        formData.append("upload_preset", preset_key);
    };

    if (
        currentPage >= picturesList.totalPages &&
        picturesList.totalPages != 0
    ) {
        setCurrentPage(picturesList.totalPages - 1);
    }

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
            <div className={styles["add-picture"]}>
                <DrugNDropWindow
                    handleAgree={onPictureCreate}
                    render={(handleClick) => (
                        <Button
                            customStyles={styles["create-btn"]}
                            title={"Upload picture"}
                            handleClick={handleClick}
                        >
                            Delete
                        </Button>
                    )}
                    handleClose={() => setPicture([])}
                    currentValue={null}
                    onChangeValue={() => handleChange}
                ></DrugNDropWindow>
            </div>
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
                                    canBeManaged={
                                        userId == picture.authorId ||
                                        userRole == "Administrator"
                                    }
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
