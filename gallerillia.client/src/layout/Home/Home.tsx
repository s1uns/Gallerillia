import { FC, useState } from "react";
import { Album, AlbumProps } from "../../components/Album/Album";
import styles from "./Home.module.scss";
import { Pagination } from "../../components/Pagination/Pagination";

export const Home: FC = () => {
    const [albums, setAlbums] = useState<AlbumProps[]>([
        { id: "1", title: "Nature", imgUrl: "", author: "Illia" },
        {
            id: "2",
            title: "Life",
            imgUrl: "https://i0.wp.com/picjumbo.com/wp-content/uploads/beautiful-nature-mountain-scenery-with-flowers-free-photo.jpg?w=600&quality=80",
            author: "Michael",
        },
        { id: "3", title: "Family", imgUrl: "", author: "Illia" },
        { id: "4", title: "Nature", imgUrl: "", author: "George" },
        { id: "5", title: "Nature", imgUrl: "", author: "Betsy" },
    ]);
    return (
        <div className={styles["home"]}>
            <div className={styles["container"]}>
                <div className={styles["albums"]}>
                    {albums.map((album) => (
                        <Album key={album.id} {...album} />
                    ))}
                </div>
                <Pagination
                    currentPage={0}
                    onChangePage={() => {}}
                    totalPages={15}
                />
            </div>
        </div>
    );
};
