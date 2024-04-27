import { FC, useEffect, useState } from "react";
import { AlbumList } from "../../components/AlbumList/AlbumList";
import styles from "./MyAlbumsPage.module.scss";
import { TitleDialogWindow } from "../../components/DialogWindow/TitleDialogWindow";
import { Button } from "../../components/Button/Button";
import { useNavigate } from "react-router-dom";
import { IPageProps } from "../../types/interfaces";
import { toast } from "react-toastify";
import { createAlbum } from "../../services/api";

const MyAlbumsPage: FC<IPageProps> = (props: IPageProps) => {
    const [albumTitle, setAlbumTitle] = useState<string>("");
    const [shouldRefill, setShouldRefill] = useState<boolean>(false);
    const navigate = useNavigate();
    const updateTitleInput = (e: React.ChangeEvent<HTMLInputElement>) => {
        setAlbumTitle((oldTitle) => e.target.value);
    };

    const onAlbumCreate = () => {
        if (albumTitle.trim().length < 5 || albumTitle.trim().length > 19) {
            toast.error(
                "The album title should be between 5 and 50 characters long"
            );
            return;
        }
        const response = createAlbum({ title: albumTitle });
        response
            .then((data) => {
                toast.success(data);
                setShouldRefill(true);
            })
            .catch((error: any) => {
                if (error.response) {
                    toast.error(error.response.data);
                }
            });
        setAlbumTitle("");
        setShouldRefill(false);

    };

    useEffect(() => {
        if (!props.isLogged) {
            props.setCurrentPage("Login");
            toast.warn("You need to login first.");
            return navigate("/login");
        }
    }, []);

    return (
        <div className={styles["album-page"]}>
            <div className={styles["add-album"]}>
                <TitleDialogWindow
                    entityName="album"
                    handleAgree={onAlbumCreate}
                    handleClose={() => setAlbumTitle("")}
                    currentValue={albumTitle}
                    onChangeValue={updateTitleInput}
                    render={(handleClick) => (
                        <Button
                            customStyles={styles["create-btn"]}
                            title={"Create album"}
                            handleClick={handleClick}
                        >
                            Create
                        </Button>
                    )}
                ></TitleDialogWindow>
            </div>
            <AlbumList shouldRefill={shouldRefill} albumsType="my-albums" />
        </div>
    );
};

export default MyAlbumsPage;
